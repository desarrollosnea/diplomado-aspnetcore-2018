import axios from "axios";

const requestEquipoType = 'REQUEST_EQUIPO';
const receiveEquipoType = 'RECEIVE_EQUIPO';

const requestLoginType = 'REQUEST_LOGIN';
const receiveLoginType = 'RECEIVE_LOGIN';
const receiveErrorLoginType = 'RECEIVE_ERROR_LOGIN';

const requestProcesarEquipoType = 'REQUEST_PROCESAR_EQUIPO';
const receiveProcesarEquipoType = 'RECEIVE_PROCESAR_EQUIPO';
const receiveErrorEquipoType = 'RECEIVE_ERROR_GUARDAR_EQUIPO';

const initialState = {
    equipos: [], isLoading: false, procesado: false, error: false,
    actualizarGrilla: false, logeado: false, errorLogin: false
};

export const actionCreators = {
    login: () => async (dispatch, getState) => {

        dispatch({ type: requestLoginType });
        let usuario = {
            username: "asd",
            password: "dsa"
        }
        axios({
            url: `http://localhost:9100/api/token`,
            method: "POST",
            data: usuario
        })
            .then(response => {
                //guardar token en localstorage
                localStorage.setItem("token", response.data.token);

                dispatch({ type: receiveLoginType });
            })
            .catch(response => {
                dispatch({ type: receiveErrorLoginType });
            });
    },

    requestEquipos: () => async (dispatch, getState) => {    

        dispatch({ type: requestEquipoType });

        const token = localStorage.getItem("token");

        axios({
            url: `http://localhost:9100/api/equipo`,
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + token
            },
        })
        .then(response => {
          dispatch({
              type: receiveEquipoType,
              payload: response.data,
          });
        })
        .catch(response => {
          console.log(response);
        });
    },

    guardarEquipo: (equipo) => async (dispatch, getState) => {

        dispatch({ type: requestProcesarEquipoType });

        const token = localStorage.getItem("token");

        axios({
            url: `http://localhost:9100/api/equipo`,
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + token
            },
            data: equipo
        })
        .then(response => {
            dispatch({ type: receiveProcesarEquipoType});
        })
        .catch(response => {
            dispatch({ type: receiveErrorEquipoType });
        });
    },

    eliminarEquipo: (equipoId) => async (dispatch, getState) => {

        dispatch({ type: requestProcesarEquipoType });

        const token = localStorage.getItem("token");

        axios({
            url: `http://localhost:9100/api/equipo/${equipoId}`,
            method: "DELETE",
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + token
            },
        })
            .then(response => {
                dispatch({ type: receiveProcesarEquipoType});
            })
            .catch(response => {
                dispatch({ type: receiveErrorEquipoType });
            });
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    switch (action.type) {
        case requestEquipoType:
            return Object.assign({}, state, {
                isLoading: true,
                actualizarGrilla: false
            });

        case receiveEquipoType:
            return Object.assign({}, state, {
                equipos: action.payload,
                isLoading: false
            });

        case requestProcesarEquipoType:
            return Object.assign({}, state, {
                procesado: false,
                error: false,
                isLoading: true
            });

        case receiveProcesarEquipoType:
            return Object.assign({}, state, {
                procesado: true,
                error: false,
                isLoading: false,
                actualizarGrilla: true
            });

        case receiveErrorEquipoType:
            return Object.assign({}, state, {
                procesado: false,
                error: true,
                isLoading: false,
                actualizarGrilla: false
            });

        case requestLoginType:
            return Object.assign({}, state, {
                logeado: false,
                errorLogin: false,
                isLoading: true
            });

        case receiveLoginType:
            return Object.assign({}, state, {
                logeado: true,
                errorLogin: false,
                isLoading: false,
            });

        case receiveErrorLoginType:
            return Object.assign({}, state, {
                logeado: false,
                errorLogin: true,
                isLoading: false,
            });

        default:
            return state;
    }

  
};

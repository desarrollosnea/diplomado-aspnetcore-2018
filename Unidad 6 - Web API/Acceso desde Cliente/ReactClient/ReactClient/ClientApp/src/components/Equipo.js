import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Equipo';

const equipoTest = {
    nombre: "Equipo Test",
    codigo: "test"
}

class Equipo extends Component {
    constructor(props) {
        super(props);
        this.handleDelete = this.handleDelete.bind(this);
    }

    componentWillMount() {
        //agregar login
        this.props.login();

        // This method runs when the component is first added to the page
        this.props.requestEquipos();
    }

    componentDidUpdate() {
      if (this.props.actualizarGrilla) 
          this.props.requestEquipos();
    }

    handleDelete(equipoId) {
        this.props.eliminarEquipo(equipoId)
    }


  render() {
    return (
      <div>
            <h1>Equipos</h1>

            <button onClick={() => this.props.guardarEquipo(equipoTest)}>Nuevo Equipo</button>

            {renderForecastsTable(this.props, this.handleDelete)}
      </div>
    );
  }
}

function renderForecastsTable(props, handleDelete) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Codigo</th>
          <th>Accion</th>
        </tr>
      </thead>
      <tbody>
        {props.equipos && props.equipos.map(equipo =>
          <tr key={equipo.equipoId}>
            <td>{equipo.nombre}</td>
            <td>{equipo.codigo}</td>
            <td>
                <button onClick={()=> handleDelete(equipo.equipoId)}>Eliminar</button>
            </td>
          </tr>
        )}
      </tbody>
    </table>
  );
}


export default connect(
  state => state.equipos,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Equipo);

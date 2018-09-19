using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProdeDBFirst.Controllers;
using ProdeDBFirst.Entidades;
using ProdeDBFirst.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdeDBFirst.Unit.Test.Controllers
{
    class EquipoControllerTests
    {
		#region Setup
		private EquipoController _equipoController;
		private Mock<IEquipoNegocio> _equipoNegocio;

		[SetUp()]
		public void Setup()
		{
			_equipoNegocio = new Mock<IEquipoNegocio>();

			_equipoController = new EquipoController(_equipoNegocio.Object) {
				EquipoNegocio = _equipoNegocio.Object
			};
		}

		#endregion
		#region Details
		[Test]
		public async Task Details_CuandoIdEsNulo_DevuelveNotFound()
		{
			var result =await  _equipoController.Details(null);
			var resultadoEsperado = result as NotFoundResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(resultadoEsperado);
			Assert.AreEqual(resultadoEsperado.StatusCode, 404);
		}

		[Test]
		public async Task Details_CuandoFalla_DevuelveBadRequest()
		{
			_equipoNegocio
				.Setup(x => x.GetById(It.IsAny<int>()))
				.Throws(new Exception());

			var equipoId = 1;

			var result = await _equipoController.Details(equipoId);
			var resultadoEsperado = result as BadRequestObjectResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(resultadoEsperado);
			Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
			Assert.AreEqual(resultadoEsperado.Value, "Ha ocurrido un error al intentar obtener el detalle del equipo.");
		}

		[Test]
		public async Task Details_CuandoNoEncuentraEquipo_DevuelveNotFound()
		{
			_equipoNegocio
				.Setup(x => x.GetById(It.IsAny<int>()))
				.Returns(Task.FromResult((Equipo)null));

			var equipoId = 1;
			var result = await _equipoController.Details(equipoId);
			var resultadoEsperado = result as NotFoundResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(resultadoEsperado);
			Assert.AreEqual(resultadoEsperado.StatusCode, 404);

		}

		[Test]
		public async Task Details_CuandoTodoOk_DevuelveViewResult()
		{
			_equipoNegocio
				.Setup(x => x.GetById(It.IsAny<int>()))
				.Returns(Task.FromResult(EquipoFake()));

			var equipoId = 1;
			var result = await _equipoController.Details(equipoId);
			var resultadoEsperado = result as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(resultadoEsperado);
			Assert.IsInstanceOf(typeof(Equipo), resultadoEsperado.Model);
			Assert.IsTrue(string.IsNullOrEmpty(resultadoEsperado.ViewName) || resultadoEsperado.ViewName == "Index");
			//Assert.IsNull(resultadoEsperado.ViewName);
			//Assert.vi
		}

		#endregion
		#region Create
		#endregion
		#region Delete

		#endregion

		#region Fakes
		private Equipo EquipoFake()
		{
			return new Equipo();
		}
		#endregion
	}
}

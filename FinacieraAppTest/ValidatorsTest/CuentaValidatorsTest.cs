using FinanceApp.web.Models;
using FinanceApp.web;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;
using FinanceApp.web.Validators;
using Microsoft.EntityFrameworkCore;

namespace FinacieraAppTest.ValidatorsTest
{

    public class CuentaValidatorsTest
    {
        [Test]
        public void hasUniqueName1()
        {
            var CuentasList = new List<Cuenta>()
            {
                new Cuenta() {Id=1,Nombre="pedro",Monto=200 },
                new Cuenta() {Id=2,Nombre="pablo",Monto=100}
            };

            var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcmok.Setup(o => o.Cuentas).ReturnsDbSet(CuentasList);

            var newcuenta = new Cuenta
            {
                Id = 3,
                Nombre = "angel",
                Monto = 200
            };

            var reult = CuentaValidator.hasUniqueName(rcmok.Object, newcuenta);

            Assert.False(reult);
        }

        [Test]
        public void hasUniqueName2()
        {
            var CuentasList = new List<Cuenta>()
            {
                new Cuenta() {Id=1,Nombre="pedro",Monto=200 },
                new Cuenta() {Id=2,Nombre="pablo",Monto=100}
            };

            var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcmok.Setup(o => o.Cuentas).ReturnsDbSet(CuentasList);

            var newcuenta = new Cuenta
            {
                Id = 3,
                Nombre = "pedro",
                Monto = 200
            };

            var reult = CuentaValidator.hasUniqueName(rcmok.Object, newcuenta);

            Assert.That(reult, Is.True);
        }

        [Test]
        public void hasUniqueName3()
        {
            var CuentasList = new List<Cuenta>()
            {
                new Cuenta() {Id=1,Nombre="pedro",Monto=200 },
                new Cuenta() {Id=2,Nombre="pablo",Monto=100}
            };

            var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcmok.Setup(o => o.Cuentas).ReturnsDbSet(CuentasList);

            var newcuenta = new Cuenta
            {
                Id = 3,
                Nombre = "pablo",
                Monto = 200
            };

            var reult = CuentaValidator.hasUniqueName(rcmok.Object, newcuenta);

            Assert.True(reult);
        }

    }
}

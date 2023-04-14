using FinanceApp.web;
using FinanceApp.web.Models;
using FinanceApp.web.Validators;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinacieraAppTest.ValidatorsTest
{
    internal class TransaccionValidatorTest
    {
        [Test]
        public void HasValidCategory1()
        {
            var Transaccioneslist = new List<Transaccion>
            {
                new Transaccion()
                {
                    Id = 1,
                    Fecha=Convert.ToDateTime("14-04-2023"),
                    CuentaId=1,
                    CategoryId=1,
                    Monto=200,
                    Nota="hola"

                },
                new Transaccion()
                {
                    Id = 2,
                    Fecha=Convert.ToDateTime("15-04-2023"),
                    CuentaId=2,
                    CategoryId=2,
                    Monto=200,
                    Nota="hola"
                }
            };
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="interbancaria",

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="local"
                }
            };

            var newtransaccion = new Transaccion()
            {
                Id=3,
                Fecha = Convert.ToDateTime("15-04-2023"),
                CuentaId=3,
                CategoryId=3,
                Monto=200,
                Nota="FALSO"

            };
            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(o => o.Transacciones).ReturnsDbSet(Transaccioneslist);
            rcMock.Setup(w => w.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.HasValidCategory(rcMock.Object,newtransaccion);

            Assert.False(result);

        }

        [Test]
        public void HasValidCategory2()
        {
            var Transaccioneslist = new List<Transaccion>
            {
                new Transaccion()
                {
                    Id = 1,
                    Fecha=Convert.ToDateTime("14-04-2023"),
                    CuentaId=1,
                    CategoryId=1,
                    Monto=200,
                    Nota="hola"

                },
                new Transaccion()
                {
                    Id = 2,
                    Fecha=Convert.ToDateTime("15-04-2023"),
                    CuentaId=2,
                    CategoryId=2,
                    Monto=200,
                    Nota="hola"
                }
            };
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="interbancaria",

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="local"
                }
            };

            var newtransaccion = new Transaccion()
            {
                Id = 3,
                Fecha = Convert.ToDateTime("15-04-2023"),
                CuentaId = 3,
                CategoryId = 2,
                Monto = 200,
                Nota = "FALSO"

            };
            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(o => o.Transacciones).ReturnsDbSet(Transaccioneslist);
            rcMock.Setup(w => w.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.HasValidCategory(rcMock.Object, newtransaccion);

            Assert.True(result);

        }

        [Test]
        public void HasValidCategory3()
        {
            var Transaccioneslist = new List<Transaccion>
            {
                new Transaccion()
                {
                    Id = 1,
                    Fecha=Convert.ToDateTime("14-04-2023"),
                    CuentaId=1,
                    CategoryId=1,
                    Monto=200,
                    Nota="hola"

                },
                new Transaccion()
                {
                    Id = 2,
                    Fecha=Convert.ToDateTime("15-04-2023"),
                    CuentaId=2,
                    CategoryId=2,
                    Monto=200,
                    Nota="hola"
                }
            };
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="interbancaria",

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="local"
                }
            };

            var newtransaccion = new Transaccion()
            {
                Id = 3,
                Fecha = Convert.ToDateTime("15-04-2023"),
                CuentaId = 3,
                CategoryId = 1,
                Monto = 200,
                Nota = "TRUE"

            };
            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(o => o.Transacciones).ReturnsDbSet(Transaccioneslist);
            rcMock.Setup(w => w.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.HasValidCategory(rcMock.Object, newtransaccion);

            Assert.True(result);

        }
        [Test]
        public void IsValidAmountBasedCategory1()
        {
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="soles",
                    Tipo="EGRESOS"

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="dolares",
                    Tipo="INGRESOS"
                    
                }
            };

          var newTransaccion=  new Transaccion()
          {
                Id = 1,
                Fecha = Convert.ToDateTime("14-04-2023"),
                CuentaId = 1,
                CategoryId = 1,
                Monto =-30,
                Nota = "hola"
          };
               
            



            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(c => c.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.IsValidAmountBasedCategory(rcMock.Object, newTransaccion);

            Assert.False(result);
           
        }

        [Test]
        public void IsValidAmountBasedCategory2()
        {
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="soles",
                    Tipo="EGRESOS"

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="dolares",
                    Tipo="INGRESOS"

                }
            };

            var newTransaccion = new Transaccion()
            {
                Id = 1,
                Fecha = Convert.ToDateTime("14-04-2023"),
                CuentaId = 1,
                Monto = 30,
                Nota = "hola"
            };





            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(c => c.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.IsValidAmountBasedCategory(rcMock.Object, newTransaccion);

            Assert.False(result);

        }

        [Test]
        public void IsValidAmountBasedCategory3()
        {
            var Categoriaslist = new List<Categoria>
            {
                new Categoria()
                {
                    Id=1,
                    Nombre="soles",
                    Tipo="EGRESOS"

                },
                new Categoria()
                {
                    Id=2,
                    Nombre="dolares",
                    Tipo="INGRESOS"

                }
            };

            var newTransaccion = new Transaccion()
            {
                Id = 1,
                Fecha = Convert.ToDateTime("14-04-2023"),
                CuentaId = 1,
                CategoryId = 2,
                Monto = 30,
                Nota = "hola"
            };





            var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
            rcMock.Setup(c => c.Categorias).ReturnsDbSet(Categoriaslist);

            var result = TransaccionValidator.IsValidAmountBasedCategory(rcMock.Object, newTransaccion);

            Assert.False(result);

        }
    }
}

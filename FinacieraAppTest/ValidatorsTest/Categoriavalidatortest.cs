using FinanceApp.web;
using FinanceApp.web.Models;
using FinanceApp.web.Validators;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace FinacieraAppTest.ValidatorsTest;


public class Categoriavalidatortest
{
    [Test]
    public void Hasuniquename1()
    {

        var categoria = new List<Categoria>
        {
            new Categoria { Id = 1,Nombre="DOLARES"},
            new Categoria {Id=2,Nombre="SOLES"}

        };
        var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "DOLARES"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.True);

    }

    [Test]
    public void Hasuniquename2()
    {

        var categoria = new List<Categoria>
        {
             new Categoria { Id = 1,Nombre="DOLARES"},
            new Categoria {Id=2,Nombre="SOLES"}

        };
        var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "OTRO"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.False);

    }

    [Test]
    public void Hasuniquename3()
    {

        var categoria = new List<Categoria>
        {
               new Categoria { Id = 1,Nombre="DOLARES"},new Categoria {Id=2,Nombre="SOLES"}
        };
        var rcmok = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "OTRO"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.False);

    }
    [Test]
    public void hasValidType1()
    {
        var newcategoria = new Categoria()
        {
            Id = 1,
            Nombre = "DOLARES",
            Tipo="EGRESO"
        };

        var result = CategoriaValidator.hasValidType(newcategoria);

        Assert.That(result, Is.True);
    }
    [Test]
    public void hasValidType2()
    {
        var newcategoria = new Categoria()
        {
            Id = 1,
            Nombre = "INGRESO",
            Tipo="INGRESO"
        };

        var result = CategoriaValidator.hasValidType(newcategoria);

        Assert.That(result, Is.True);
    }
    [Test]
    public void hasValidType3()
    {
        var newcategoria = new Categoria()
        {
            Id = 1,
            Nombre = "DOLARES",
            Tipo="OTRO"
        };

        var result = CategoriaValidator.hasValidType(newcategoria);

        Assert.That(result, Is.False);
    }




}
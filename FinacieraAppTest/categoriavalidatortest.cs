using FinanceApp.web;
using FinanceApp.web.Models;
using FinanceApp.web.Validators;
using Moq;
using Moq.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace FinacieraAppTest;

public class categoriavalidatortest
{
    [Test]
    public void Hasuniquename1(){

        var categoria = new List<Categoria>
        {
            new Categoria { Id = 1,Nombre="vaca"},
            new Categoria {Id=2,Nombre="apio"}

        };
        var rcmok = new Mock<DbEntities>();
            rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "vaca"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.False);
    
    }

    [Test]
    public void Hasuniquename2()
    {

        var categoria = new List<Categoria>
        {
            new Categoria { Id = 1,Nombre="vaca"},
            new Categoria {Id=2,Nombre="apio"}

        };
        var rcmok = new Mock<DbEntities>();
        rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "algo"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.True);

    }

    [Test]
    public void Hasuniquename3()
    {

        var categoria = new List<Categoria>
        {
            new Categoria { Id = 1,Nombre="vaca"},
            new Categoria {Id=2,Nombre="apio"}

        };
        var rcmok = new Mock<DbEntities>();
        rcmok.Setup(o => o.Categorias).ReturnsDbSet(categoria);

        var newcategoria = new Categoria
        {
            Nombre = "algo1"
        };

        var result = CategoriaValidator.hasUniqueName(rcmok.Object, newcategoria);

        Assert.That(result, Is.True);

    }

}
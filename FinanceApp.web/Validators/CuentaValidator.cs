using FinanceApp.web.Models;

namespace FinanceApp.web.Validators;

public class CuentaValidator
{
    public static bool hasUniqueName(DbEntities entities, Cuenta cuenta)
    {
        return entities.Cuentas.Any(o => o.Nombre == cuenta.Nombre);
    }
}
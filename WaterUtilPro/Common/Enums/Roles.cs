namespace WaterUtilPro.Common.Enums
{
    public enum Roles
    {
        SuperAdmin, //Admin only Admin Roles/Users Does not hold value to operations.
        Admin, //Access to update company / user accounts. No other value to operation        
        Manager, //Access to employee / Create,Update,Delete,Read all company operations - may also be Admin 
        Associate, //Create,Update,Delete,Read all company operations - may have limited overrides.
                 // Policies will exist to support role permissions.
    }
}

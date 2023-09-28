
namespace Framework.Identity
{
    public interface IIdentityService
    {
        /// <summary>
        /// Gets current employee id based on the "name" claim type provided by JWT token
        /// </summary>
        /// <returns>Guid</returns>
        Guid GetCurrentEmployeeId();
        /// <summary>
        /// Gets current employee personnel code based on the "name" claim type provided by JWT token
        /// </summary>
        /// <returns>string</returns>
        string GetCurrentEmployeePersonnelCode();
    }

}
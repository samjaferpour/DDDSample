using System.Runtime.CompilerServices;

// Make internals visible to the Infrastructure project for EF Core
[assembly: InternalsVisibleTo("Infrastructure")]
// Make internals visible to the Application project if needed
[assembly: InternalsVisibleTo("Application")] 
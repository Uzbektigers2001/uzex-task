using System.Collections.Generic;

namespace MockTask.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public List<string> CollectionNames { get; set; } = null!;
    }
}

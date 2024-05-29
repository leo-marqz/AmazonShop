
namespace AmazonShop.Domain.Models
{
    public class OrderAddress
    {
       /// <summary>
        /// Detalla tu direccion como calle, numero de casa, etc.
        /// </summary>
        /// <value></value>
        public string Detail { get; set; }

        /// <summary>
        /// Nombre de la ciudad.
        /// </summary>
        /// <value></value>
        public string City { get; set; }

        /// <summary>
        /// La region puede representar una provincia, departamento, estado, etc. siempre dentro del contexto de un pais.
        /// </summary>
        /// <value></value>
        public string Region { get; set; }

        /// <summary>
        /// Codigo Postal
        /// </summary>
        /// <value></value>
        public string ZipCode { get; set; }

        /// <summary>
        /// Nombre de pais
        /// </summary>
        /// <value></value>
        public string Country { get; set; }

        /// <summary>
        /// Usuario al que esta relacionada la direccion dada.
        /// </summary> <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Username { get; set; } 
    }
}

using System.Runtime.Serialization;

namespace AmazonShop.Domain.Models
{
    public enum OrderStatus
    {
        /// <summary>
        /// La orden ha sido creada pero no ha sido procesada aún.
        /// </summary>
        [EnumMember(Value = "Pendiente")]
        Pending,      

        /// <summary>
        /// La orden está siendo procesada.
        /// </summary>
        [EnumMember(Value = "Procesando")]
        Processing,     

        /// <summary>
        /// La orden ha sido enviada al cliente.
        /// </summary>
        [EnumMember(Value = "Enviado")]
        Shipped,     

        /// <summary>
        /// La orden ha sido entregada al cliente.
        /// </summary>
        [EnumMember(Value = "Entragado")]
        Delivered,   

        /// <summary>
        /// La orden ha sido cancelada.
        /// </summary>
        [EnumMember(Value = "Cancelado")]
        Canceled, 

        /// <summary>
        /// El cliente ha devuelto la orden.
        /// </summary>
        [EnumMember(Value = "Devuelto")]
        Returned  
    }
}
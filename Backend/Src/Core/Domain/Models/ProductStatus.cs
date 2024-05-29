

using System.Runtime.Serialization;

namespace AmazonShop.Domain.Models
{
    public enum ProductStatus
    {
        /// <summary>
        /// El producto está disponible para la venta y puede ser comprado por los clientes.
        /// </summary>
        ///
        [EnumMember(Value = "Disponible")]
        Available, 

        /// <summary>
        /// El producto está actualmente fuera de stock y no puede ser comprado hasta que se reponga
        /// </summary>
        ///
        [EnumMember(Value = "Agotado")]
        OutOfStock,
        
        /// <summary>
        /// El producto ya no se vende y no estará disponible para la compra en el futuro.
        /// </summary>
        /// 
        [EnumMember(Value = "Descontinuado")]
        Discontinued,

        /// <summary>
        /// El producto está en proceso de ser repuesto y pronto estará disponible para la venta.
        /// </summary>
        /// 
        [EnumMember(Value = "En Reposicion")]
        Restocking,

        /// <summary>
        /// El producto aún no está disponible para la venta inmediata, pero los clientes pueden preordenarlo para recibirlo en una fecha posterior.
        /// </summary>
        /// 
        [EnumMember(Value = "Pre-Orden")]
        PreOrder,

        /// <summary>
        /// El producto está en oferta o descuento, lo que significa que se vende a un precio reducido durante un periodo de tiempo limitado.
        /// </summary>
        /// 
        [EnumMember(Value = "En Descuento")]
        OnSale, 

        /// <summary>
        /// El producto ha sido reservado por un cliente y no está disponible para otros compradores.
        /// </summary>
        [EnumMember(Value = "Reservado")]
        Reserved,

        /// <summary>
        ///  El producto está siendo trasladado, ya sea al almacén o al cliente, y aún no está disponible para la venta inmediata.
        /// </summary>
        ///
        [EnumMember(Value = "En Transito")]
        InTransit
    }
}

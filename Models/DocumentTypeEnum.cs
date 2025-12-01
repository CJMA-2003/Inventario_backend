namespace Inventario.Models
{
    public enum DocumentTypeEnum
    {
        PurchaseInvoice,       // Factura de compra
        SalesInvoice,          // Factura de venta
        CreditNote,            // Nota de crédito
        DebitNote,             // Nota de débito
        EntryAdjustment,       // Ajuste de entrada
        ExitAdjustment,        // Ajuste de salida
        TransferEntry,         // Entrada por traslado
        TransferExit,          // Salida por traslado
        InternalUse,           // Consumo interno
        RemissionGuideEntry,   // Guía de remisión (entrada)
        RemissionGuideExit     // Guía de remisión (salida)
    }
}

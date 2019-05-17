using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Proyecto.Models
{
    public class zt_cat_cedis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdCEDI { get; set; }
        [StringLength(50)]
        public string DesCEDI { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    } // cedis
    public class zt_cat_almacenes
    {
        [StringLength(20)]
        public string IdAlmacen { get; set; } //pk
        public Int16 IdCEDI { get; set; }
        public zt_cat_cedis zt_cat_cedis { get; set; }
        [StringLength(50)]
        public string DesAlmacen { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }// almacenes
    
    public class zt_cat_grupos_sku
    {
        [StringLength(20)]
        public string IdGrupoSKU { get; set; } //pk
        [StringLength(50)]
        public string DesGrupoSKU { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    } // grupos

    public class zt_cat_unidad_medidas
    {
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }//pk
        [StringLength(20)]
        public string DesUMedida { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }// unidades-medidas

    public class zt_cat_productos
    {
        [StringLength(20)]
        public string IdSKU { get; set; }//pk
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        [StringLength(50)]
        public string DesSKU { get; set; }
        [StringLength(20)]
        public string IdGrupoSKU { get; set; }
        public zt_cat_grupos_sku zt_cat_grupos_sku { get; set; }//fk
        [StringLength(10)]
        public string IdUMedidaBase { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }//fk
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }// productos

    public class zt_cat_productos_medidas
    {
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        [StringLength(10)]
        public string IdUMedidaBase { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }//fk
        public float CantidadPZA { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }// producto-unidad-medida

    public class zt_cat_ubicaciones
    {
        [StringLength(20)]
        public string IdUbicacion { get; set; }//pk
        [StringLength(50)]
        public string DesUbicacion { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    } //ubicaciones

    public class zt_almacenes_ubicaciones
    {
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        public zt_cat_almacenes zt_cat_almacenes { get; set; }//fk
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public zt_cat_ubicaciones zt_cat_ubicaciones { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
    } // almacen-ubicacion

    public class zt_cat_estatus
    {
        [StringLength(20)]
        public string IdEstatus { get; set; }//pk
        [StringLength(50)]
        public string DesEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
    } // estatus

    public class zt_inventarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdInventario { get; set; }//pk
        public Int16 idCEDI { get; set; }
        public zt_cat_cedis zt_cat_cedis { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        public zt_cat_almacenes zt_cat_almacenes { get; set; }
        [StringLength(20)]
        public string IdEstatus { get; set; }
        public zt_cat_estatus zt_cat_estatus { get; set; }
        [StringLength(20)]
        public string IdInventarioSAP { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    } // inventarios

    public class zt_inventarios_acumulados
    {        
        public int IdInventario { get; set; }
        public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos{ get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas{ get; set; }
        public float CantadadTeorica { get; set; }
        public float CantidadTeoricaCJA { get; set; }
        public float CantidadFisica { get; set; }
        public float Diferencia { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }// inventarios-acumulados


    public class zt_inventarios_conteos
    {
        public int IdInventario { get; set; }
        public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        public zt_cat_almacenes zt_cat_almacenes{ get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public zt_cat_ubicaciones zt_cat_ubicaciones{ get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumConteo { get; set; } //pk
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        public float CantidadFisica { get; set; }
        public float CantidadPZA { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }// inventario-conteos
    public class zt_inventarios_acumulados_conteos
    {
        public List<zt_inventarios> zt_inventarios { get; set; }
        public List<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public List<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
    }

    public class zt_inventarios_conteos_grid
    {
        public string IdInventario { get; set; }
        public string NumConteo { get; set; }
        public string IdAlmacen { get; set; }
        public string IdSKU { get; set; }
        public string CantidadFisica { get; set; }   
        public string CantidadPZA { get; set; }   
        public string IdUnidadMedida { get; set; }
        public string UsuarioReg { get; set; }
    }

    public class temp_generales
    {
        public List<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public List<zt_cat_productos> zt_cat_productos { get; set; }
        public List<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public List<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        public List<zt_cat_cedis> zt_cat_cedis { get; set; }
        public List<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public List<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public List<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }
        public List<zt_cat_estatus> zt_cat_estatus { get; set; }
    }

    public class body_edit_conteo_item
    {
        public zt_cat_almacenes zt_cat_almacenes { get; set; }
        public zt_cat_productos zt_cat_productos { get; set; }
        public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
    }
}//namespace

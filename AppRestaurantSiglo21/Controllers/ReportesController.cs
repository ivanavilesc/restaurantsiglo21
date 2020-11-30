﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AppRestaurantSiglo21.Models;
using System.Data.SqlClient;


namespace AppRestaurantSiglo21.Controllers
{
    public class ReportesController : Controller
    {

        private RestaurantEntities db = new RestaurantEntities();

        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAtencionesPorDiaJSON()
        {
            //Creamos una lista del tipo de dato de la ViewModel
            List<VentaDiaViewModel> list = new List<VentaDiaViewModel>();

            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {
                //var detalleorden = (from d in db.ORDEN
                //                    group d.FECHAORDEN 
                //                    orderby d.FECHAORDEN descending

                //                    select new VentaDiaViewModel
                //                    {
                //                        CantidadVentas = d x.Count()
                //                        CantidadVentas =  d.IDORDEN,
                //                        FechaVenta = d.FECHAORDEN 
                //                    });

                //EN LA LISTA DE TIPO <VIEWMODEL> SE GUARDARÁ EL RESULTADO DE LA SIGUIENTE QUERY DE LINQ
                // Agrupa los datos de la tabla ORDEN en base a la FECHAORDEN con la hora truncada, vale decir, solo muestra fecha
                list = context.ORDEN.GroupBy(a => DbFunctions.TruncateTime(a.FECHAORDEN))
                         // Luego, hace un SELECT que inserta en el objeto de ViewModel la CantidadVentas, y la FechaVenta truncada
                         .Select(a => new VentaDiaViewModel { CantidadVentas = a.Count(), FechaVenta = (DateTime)a.Key })
                         // Luego, ordena los datos por la FECHAORDEN con la hora truncada
                         .OrderBy(a => DbFunctions.TruncateTime(a.FechaVenta))
                         //el resultSet lo convierte a una Lista
                         .ToList();
                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();
                int z = 3;
            }

            return Json(new { JSONList = list }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetIngresoDiarioJSON()
        {
            //Creamos una lista del tipo de dato de la ViewModel
            List<IngresoDiarioViewModel> list = new List<IngresoDiarioViewModel>();
            IQueryable list2 = null;
            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {

                //EN LA LISTA DE TIPO <VIEWMODEL> SE GUARDARÁ EL RESULTADO DE LA SIGUIENTE QUERY DE LINQ
                // Agrupa los datos de la tabla ORDEN en base a la FECHAORDEN con la hora truncada, vale decir, solo muestra fecha
                //list = context.ORDEN.GroupBy(a => DbFunctions.TruncateTime(a.FECHAORDEN)).Join()

                // Luego, hace un SELECT que inserta en el objeto de ViewModel la CantidadVentas, y la FechaVenta truncada

                //.Select(a => new IngresoDiarioViewModel
                // {
                //     CantidadVentas = a.Count(),
                //     FechaIngreso = (DateTime)a.Key
                // })
                // Luego, ordena los datos por la FECHAORDEN con la hora truncada
                //.OrderBy(a => DbFunctions.TruncateTime(a.FechaVenta))
                //el resultSet lo convierte a una Lista
                //.ToList();
                DateTime? fecha;
                
                list2 = from d in db.DOCUMENTOPAGO
                        group d by d.TOTAL into res
                        join o in db.ORDEN
                        on res.FirstOrDefault().IDORDEN equals o.IDORDEN
                       
                        select new IngresoDiarioViewModel
                        {
                            TotalIngreso = (int)res.Sum(d => d.TOTAL),
                            FechaIngreso = o.FECHAORDEN                          
                        };

                
                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();
                int z = 3;
            }

            return Json(new { JSONList = list2 }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTopProductosJSON()
        {
            //Creamos una lista del tipo de dato de la ViewModel
            List<TopProductosViewModel> list = new List<TopProductosViewModel>();
            IQueryable list2 = null;
            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {

                //EN LA LISTA DE TIPO <VIEWMODEL> SE GUARDARÁ EL RESULTADO DE LA SIGUIENTE QUERY DE LINQ
                // Agrupa los datos de la tabla ORDEN en base a la FECHAORDEN con la hora truncada, vale decir, solo muestra fecha
                //list = context.ORDEN.GroupBy(a => DbFunctions.TruncateTime(a.FECHAORDEN)).Join()

                // Luego, hace un SELECT que inserta en el objeto de ViewModel la CantidadVentas, y la FechaVenta truncada

                //.Select(a => new IngresoDiarioViewModel
                // {
                //     CantidadVentas = a.Count(),
                //     FechaIngreso = (DateTime)a.Key
                // })
                // Luego, ordena los datos por la FECHAORDEN con la hora truncada
                //.OrderBy(a => DbFunctions.TruncateTime(a.FechaVenta))
                //el resultSet lo convierte a una Lista
                //.ToList();
                DateTime? fecha;
                list2 = (from d in db.DETALLEORDEN
                         join p in db.PRODUCTO
                         on d.IDPRODUCTO equals p.IDPRODUCTO

                         orderby d.CANTIDAD descending
                         select new TopProductosViewModel
                         {
                             CantidadProductos = (int)d.CANTIDAD,
                             DescripcionProducto = p.DESCPRODUCTO,
                         }).Take(10);
                
                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();
                int z = 3;
            }

            return Json(new { JSONList = list2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TopProductos()
        {
            //Creamos una lista del tipo de dato de la ViewModel
            List<TopProductosViewModel> list = new List<TopProductosViewModel>();
            IQueryable list2 = null;
            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {

                DateTime? fecha;
                list = (from d in db.DETALLEORDEN
                        join p in db.PRODUCTO
                        on d.IDPRODUCTO equals p.IDPRODUCTO

                        orderby d.CANTIDAD descending
                        select new TopProductosViewModel
                        {
                            CantidadProductos = (int)d.CANTIDAD,
                            DescripcionProducto = p.DESCPRODUCTO,
                        }).Take(10).ToList();

                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();
                int z = 3;
            }
            Session["topProductos"] = list;
            return View(list);
        }

        public ActionResult IngresoDiario()
        {

            List<IngresoDiarioViewModel> list = new List<IngresoDiarioViewModel>();
            IQueryable list2 = null;
            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {

                DateTime? fecha;
                list = (from o in db.ORDEN
                        join d in db.DOCUMENTOPAGO
                        on o.IDORDEN equals d.IDORDEN
                        orderby o.IDORDEN ascending
                        select new IngresoDiarioViewModel
                        {
                            TotalIngreso = (int)d.TOTAL,
                            FechaIngreso = o.FECHAORDEN,
                            MedioPago = (int)d.IDMEDIOPAGO
                        }).ToList();

                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();
                int z = 3;
            }

            Session["ingresoDiario"] = list;
            return View(list);

        }

        public ActionResult AtencionesPorDia()
        {
            List<VentaDiaViewModel> list = new List<VentaDiaViewModel>();

            //creamos un using que utiliza una variable de contexto con la conexión al EF
            using (var context = new RestaurantEntities())
            {

                list = context.ORDEN.GroupBy(a => DbFunctions.TruncateTime(a.FECHAORDEN))
                         // Luego, hace un SELECT que inserta en el objeto de ViewModel la CantidadVentas, y la FechaVenta truncada
                         .Select(a => new VentaDiaViewModel { CantidadVentas = a.Count(), FechaVenta = (DateTime)a.Key })
                         // Luego, ordena los datos por la FECHAORDEN con la hora truncada
                         .OrderBy(a => DbFunctions.TruncateTime(a.FechaVenta))
                         //el resultSet lo convierte a una Lista
                         .ToList();
                //list = context.ORDEN.Select(a => new VentaDiaViewModel { CantidadVentas = a.IDORDEN, FechaVenta = a.FECHAORDEN }).ToList();

                int z = 3;
            }
            Session["atencionesDiarias"] = list;
            return View(list);

        }

    }
}
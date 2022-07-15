using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolAutoGen.Commom;
using ToolAutoGen.ConnectBase;
using ToolAutoGen.Dao;
using ToolAutoGen.GenModel;
using ToolAutoGen.GenPackage;
using ToolAutoGen.Models;

namespace ToolAutoGen.Controllers
{
    public class HomeController : Controller
    {
        DBBase dBBase = new DBBase();
        getTableDbDao _getTableDbDao = new getTableDbDao();
        GemPackages gemPackages = new GemPackages();
        GenModelClass genModelClass = new GenModelClass();
        GenDBBase genDBBase = new GenDBBase();
        GenResponseModel genResponseModel = new GenResponseModel();
        GenFuncDao genFuncDao = new GenFuncDao();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Connect(viewConnect _viewConnect)
        {
            var data = dBBase.CheckConnection(_viewConnect);
            Session["connect"] = data;
            return RedirectToAction("GenPackage");
        }
        public ActionResult GenPackage()
        {
            var data = _getTableDbDao.getTableDB(Session["connect"] as string);
            return View(data.tableViewAll);
        }

        [HttpPost]
        public ActionResult GenTablePackage(string data)
        {
            var msg = new JTableData() { draw = 1, recordsFiltered = 0, recordsTotal = 0, data = "" };
            try
            {
                var model = data.Split('#');
                string response = string.Empty;
                string dao = string.Empty;
                string packageParam = "create or replace package PK_NamePackage is  type t_cursor is ref cursor; ";
                string package = "create or replace package body PK_NamePackage is ";
                string clsModel = string.Empty;
                response += Commoms.Response();
                for (int i = 0; i < model.Count(); i++)
                {
                    var table = _getTableDbDao.getFieldsTable(Session["connect"] as string, model[i].Replace("undefined", ""));
                    package += gemPackages.GenPackageToProcedure(table.fieldsTablesAll);
                    packageParam += gemPackages.GemPackParm(table.fieldsTablesAll);
                    clsModel += genModelClass.GenModelcls(table.fieldsTablesAll);
                    response += genResponseModel.ResponseModel(table.fieldsTablesAll);
                    dao += genFuncDao.GenDao(table.fieldsTablesAll);
                }
                package += "END PK_NamePackage ;";
                packageParam += "END PK_NamePackage;";
                msg.dataCls = clsModel;
                msg.data = package;
                msg.dataPack = packageParam;
                msg.dataConnect = Session["connect"] as string;
                msg.dataBase = genDBBase.GenclsDBbase(Session["connect"] as string);
                msg.dataResponse = response;
                msg.dataDao = dao;

                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ẽ)
            {

                throw;
            }
            
        }

        [HttpPost]
        public ActionResult GenTableType(string data)
        {
            var msg = new JTableData() { draw = 1, recordsFiltered = 0, recordsTotal = 0, data = "" };
            try
            {
                var model = data.Split('#');
                string response = string.Empty;
                string dao = string.Empty;
                string packageParam = "";
                string package = "create or replace package body PK_NamePackage is ";
                string clsModel = string.Empty;
                response += Commoms.Response();
                for (int i = 0; i < model.Count(); i++)
                {
                    var table = _getTableDbDao.getFieldsTableType(Session["connect"] as string, model[i].Replace("undefined", ""));
                    packageParam += "<b>Tên Bảng " + model[i].Replace("undefined", "") + "</b><br>";
                    packageParam += gemPackages.GenPackageType(table.fieldsTablesAll);
                }
               
                msg.dataCls = clsModel;
                msg.data = package;
                msg.dataPack = packageParam;
                msg.dataConnect = Session["connect"] as string;
                msg.dataBase = genDBBase.GenclsDBbase(Session["connect"] as string);
                msg.dataResponse = response;
                msg.dataDao = dao;

                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ẽ)
            {

                throw;
            }

        }
    }
}
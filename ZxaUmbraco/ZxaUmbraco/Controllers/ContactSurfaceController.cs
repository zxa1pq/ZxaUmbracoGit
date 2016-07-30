using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using ZxaUmbraco.Models;
using System.Xml.XPath;


namespace ZxaUmbraco.Controllers
{
    public class ContactSurfaceController: SurfaceController
    {

        public ActionResult ShowForm() {

            ContactModel myModel = new ContactModel();
            List<SelectListItem> ListOfGenders = new List<SelectListItem>();
            XPathNodeIterator iterator = umbraco.library.GetPreValues(1092);
            iterator.MoveNext();
            XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
            while (preValues.MoveNext())
            {
                string preValue = preValues.Current.Value;
                ListOfGenders.Add(new SelectListItem
                {
                    Text = preValue,
                    Value = preValue
                });
                myModel.ListOfGenders = ListOfGenders;

            }
           
            return PartialView("ContactForm", myModel);
        }
    
    
        public ActionResult HandleFormPost(ContactModel model)
        {
            
            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), CurrentPage.Id, "contactFormer");
            var myService = ApplicationContext.Services.DataTypeService;
            var SelectedGender = myService.GetAllDataTypeDefinitions().First(x => x.Id == 1092);
            int SelectedGenderPreValueId = myService.GetPreValuesCollectionByDataTypeId(SelectedGender.Id).PreValuesAsDictionary.Where(x => x.Value.Value == model.SelectedGender).Select(x => x.Value.Id).First();


            newComment.SetValue("emailFrom", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            newComment.SetValue("dropdownGender", SelectedGenderPreValueId);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    
    
    
    }
            
}
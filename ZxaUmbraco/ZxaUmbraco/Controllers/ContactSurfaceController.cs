using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using ZxaUmbraco.Models;

namespace ZxaUmbraco.Controllers
{
    public class ContactSurfaceController: SurfaceController
    {

        public ActionResult ShowForm() {

            ContactModel myModel = new ContactModel();
            return PartialView("ContactForm", myModel);
        }
    
    
        public ActionResult HandleFormPost(ContactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), CurrentPage.Id, "contactFormer");
            newComment.SetValue("emailFrom", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    
    
    
    }
            
}
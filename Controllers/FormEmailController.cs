using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Techno_Project.Models;
using Techno_Project.Repos;

namespace Techno_Project.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class FormEmailController : ControllerBase
    {
        ImailFormRepository ImailFormRepo;
        IEmailSender emailSender;
        IFormDbRepository Geneiric;
        IRequeststatus IRequeststatus;

        public FormEmailController(ImailFormRepository ImailFormRepository, IEmailSender _emailSender, IFormDbRepository IFormDbRepos, IRequeststatus _IRequeststatus)
        {
            ImailFormRepo = ImailFormRepository;
            emailSender = _emailSender;
            Geneiric = IFormDbRepos;
            IRequeststatus=_IRequeststatus;
        }

        [HttpPost]
        public async Task<ActionResult<FormEmail>> Add([FromBody] List<FormEmail> modellist)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var id = await ImailFormRepo.Add(modellist);
                }
                catch (Exception ex)
                {

                    return StatusCode(404, "There was a problem saving record in the database. Please try again.");
                }

            }
            return CreatedAtAction("Add", new { id = modellist[0].id }, modellist);
        }
        [HttpGet]

        public async Task<IActionResult> update(int id, int action, string Notes,int req_id,string userName,string status)
        {

            try
            {
                var post = await ImailFormRepo.Update(id, action, Notes);
                DateTime date = DateTime.Now;
                var statusreturn = await IRequeststatus.Update(id, userName, status, Notes);
                var data =  Geneiric.GetbyId(id) ;

                if (post == null)
                {
                    return StatusCode(404, "There was a problem saving record in the database. Please try again.");
                }

                try
                {
                    if (action == 1)
                    {
                        //requester email

                        var message = new Message(new string[] {data.Email }, "Movable Request" + "-" + data.Company, "Dear " + data.RequesterName + "\n" + "Thank you for Submitting your request." + "\n" + "This is to confirm that your request has been approved under the serial number " + "\n" +" GTR"+ data.serialNumber +"."+ "\n" + "your visitor will recieve a pincode message on his mobile number to access the " + "\n" + "gates upon arrival" + "\n" + "Thanks" + "\n"+"\n" + "O1 Management Team");
                        emailSender.SendEmail(message);
                    }
                    if (action == 2)
                    {
                        var message = new Message(new string[] { data.Email }, "Movable Request" + "-" + data.Company, "Dear " + data.RequesterName + "\n" + "Thank you for Submitting your Request" + "Please check our comments below and edit you initial request form and resubmit for approval" + "\n" + Notes+"\n \n"+ "<a href=\"http://techno-politan.xyz/#/editform/" + id + "\"></a>"+ "\n" + "Thanks" + "\n" + "O1 Management Team");
                        emailSender.SendEmail(message);
                    }
                    if (action == 3)
                    {
                        var message = new Message(new string[] { data.Email }, "Movable Request" + "-" + data.Company, "Dear " + data.RequesterName + "\n" + "Thank you for Submitting your Request" + "unfortunately your request has been rejected for below reasons" + "\n" + Notes + "\n" + "Thanks" + "\n" + "O1 Management Team");
                        emailSender.SendEmail(message);
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(404, "There was a problem sending emails. Please try again.");
                }



                return Ok(post);
            }
            catch (Exception)
            {
                return StatusCode(404, "Somthing ERROR. Please try again.");
            }
        }


    }

}

using Microsoft.Exchange.WebServices.Data;
using System;

namespace WindowsFormsApp1
{
    public class EmailErrors
    {
        private Program mProg;
        private int mErrorCode;
        private bool errorCheck;
        private string mailboxAddress;
        public EmailErrors(Program prog)
        {
            this.errorCheck = false;
            this.mProg = prog;
            this.mErrorCode = -1;
            Console.WriteLine("ALRIGHTY");
        }

        public void setErrorCheck(bool value) { this.errorCheck = value; }
        public bool getErrorCheck() { return this.errorCheck; }
        public void setErrorCode(int code) { this.mErrorCode = code; }
        public int getErrorCode() { return this.mErrorCode; }
        public void sendMilestoneTooLargeErrorEmail(string mailboxAddress)
        {
            EmailMessage email = new EmailMessage(mProg.getMService());
            //email.ToRecipients.Add("devin@denaliai.com");
            email.ToRecipients.Add(mailboxAddress);
            email.Subject = mProg.getMProjectTitle();
            email.Body = new MessageBody("The milestone you would like to add is too large. It must be consecutive after the latest milestone.");
            email.Send();
        }
        public void sendMilestoneAlreadyExistsErrorEmail(string mailboxAddress)
        {
            EmailMessage email = new EmailMessage(mProg.getMService());
            //email.ToRecipients.Add("devin@denaliai.com");
            email.ToRecipients.Add(mailboxAddress);
            email.Subject = mProg.getMProjectTitle();
            email.Body = new MessageBody("The milestone you would like to add already exists! Please try again and resend a valid milestone");
            email.Send();
        }
        public void sendMilestoneErrorEmail(string mailboxAddress)
        {
            EmailMessage email = new EmailMessage(mProg.getMService());
            //email.ToRecipients.Add("devin@denaliai.com");
            email.ToRecipients.Add(mailboxAddress);
            email.Subject = mProg.getMProjectTitle();
            email.Body = new MessageBody("The milestone you inputted is invalid");
            email.Send();
        }

        public void sendProjectDoesNotExistEmail(string mailboxAddress)
        {
            EmailMessage email = new EmailMessage(mProg.getMService());
            email.ToRecipients.Add(mailboxAddress);
            email.Subject = mProg.getMProjectTitle();
            email.Body = new MessageBody("The project you inputted does not exist in Share Point. Please try again with a new project title");
            email.Send();
        }
    }
}
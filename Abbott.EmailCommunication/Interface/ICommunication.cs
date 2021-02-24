using Abbott.CrossCutting.EmailModel;
using System;

namespace Abbott.EmailCommunication.Interface
{
    public interface ICommunication
    {
        public Boolean SendEmailRecoverPassword(ConfirmationEmail confirmation);
    }
}

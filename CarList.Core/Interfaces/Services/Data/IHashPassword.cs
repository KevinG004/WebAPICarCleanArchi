using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Core.Interfaces.Services.Data
{
    public interface IHashPassword 
    {
        string HashPassword1 (string password);
    }
}

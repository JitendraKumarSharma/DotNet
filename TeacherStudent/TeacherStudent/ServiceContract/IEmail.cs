﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudent.ServiceContract
{
    public interface IEmail
    {
        Task<bool> SendEmail(string name);
    }


}

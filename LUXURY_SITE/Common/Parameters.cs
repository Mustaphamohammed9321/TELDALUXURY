﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUXURY_SITE.Common
{
    public enum OperationType
    {
        CreateUserAccount = 1, //set statusid to be 1(active)
        UpdateUserAccount = 2,
        ChangeUserPassword = 3,
        GetAllUsers = 4,
        GetUserById = 5,
        DeleteUserAccount = 6,   //ie change the account status to isDeleted=1 and StatusId=0
        GetFirstname = 7,
        UserLogin = 8


        ////operation type for Staff Login
        //GetAllStaffLogin = 10,
        //GetStaffLoginById = 11,
        //CreateStaffAccount = 12,
        //StaffLoginSignIn = 13,
        //DeleteStaffAccount = 14
    }
}
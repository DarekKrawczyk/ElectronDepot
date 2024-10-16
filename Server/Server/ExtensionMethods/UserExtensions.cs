﻿using ElectroDepotClassLibrary.DTOs;
using Server.Models;

namespace Server.ExtensionMethods
{
    public static class UserExtensions
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO(
                user.UserID,
                user.Username,
                user.Email
            );
        }

        public static User ToUser(this UserDTO userDTO)
        {
            return new User()
            {
                UserID = userDTO.ID,
                Username = userDTO.Username,
                Email = userDTO.Email
            };
        }

        public static User ToUser(this CreateUserDTO userDTO)
        {
            return new User()
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
        }

        public static User ToUser(this UpdateUserDTO userDTO)
        {
            return new User()
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
        }
    }
}

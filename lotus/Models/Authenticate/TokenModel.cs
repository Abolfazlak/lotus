﻿using System;
namespace lotus.Models.Authenticate
{
	public class TokenModel
	{
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

﻿namespace Quizlo.API.DTOs;

public class TokenDto
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
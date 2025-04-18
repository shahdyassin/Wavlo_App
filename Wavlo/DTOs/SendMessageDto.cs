﻿namespace Wavlo.DTOs
{
    public class SendMessageDto
    {
        public int RoomId { get; set; }
        public string Message { get; set; }
        public string? AttachmentUrl { get; set; }
        public bool IsPrivate { get; set; }
        public string? TargetUserId { get; set; }
    }
}

﻿namespace Wavlo.DTOs
{
    public class ChatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGroup { get; set; }
        public string Type { get; set; }
        public List<string> UserIds { get; set; }
    }
}

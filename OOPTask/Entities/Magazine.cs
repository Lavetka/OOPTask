﻿using System;
namespace OOPTask.Entities
{
    public class Magazine : Document
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int ReleaseNumber { get; set; }
        public DateTime PublishDate { get; set; }
    }
}


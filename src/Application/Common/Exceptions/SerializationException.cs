﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Common.Exceptions;
public class SerializationException : Exception
{
    public SerializationException(string message)
        : base(message)
    {
    }
}

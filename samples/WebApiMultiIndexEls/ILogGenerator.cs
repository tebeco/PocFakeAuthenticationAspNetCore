using System;

namespace WebApiMultiIndexEls
{
    public interface ILogGenerator
    {
        void Unhandled();
        void Trace();
        void Debug();
        void Info();
        void Warn();
        void Error();
        void ErrorFromException(Exception ex);
        void Critical();
    }
}
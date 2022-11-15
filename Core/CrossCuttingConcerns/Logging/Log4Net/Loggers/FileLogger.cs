using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.log4net.Loggers
{
  public class FileLogger : LoggerServiceBase
  {
    public FileLogger() : base("JsonFileLogger")
    {
    }
  }
}

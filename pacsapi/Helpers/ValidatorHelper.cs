using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahas.Helpers
{
    public class ValidatorHelper
    {
        public const string DefaultRequiredMessage = "{PropertyName} belum diisi";

        public const string DefaultWrongFormat = "Format {PropertyName} tidak sesuai";

        public const string DefaultInvalidDateFormat = "Format Tanggal Tidak Sesuai, format yang benar adalah yyyy-mm-dd";
    }
}

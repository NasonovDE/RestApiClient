using System.ComponentModel.DataAnnotations;

namespace RestApiClient.Models
{
    public enum QRcode
    {
        [Display(Name = "Требуется наличие QR кода")]
        QRcodeYes = 1,

        [Display(Name = "QR код не требуется")]
        QRcodeNo = 2,

    }
}
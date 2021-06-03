using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum TipoAsistencia: System.Int64
    {
            AUSENTE = 0,
            PRESENTE = 1,
            JUSTIFICADO = 2,
            TARDIO = 3
    }
}
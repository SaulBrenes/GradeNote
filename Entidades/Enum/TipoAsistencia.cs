using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum TipoAsistencia: System.Int64
    {
            Ausente = 0,
            Presente = 1,
            Justificado = 2,
            Tardio = 3
    }
}
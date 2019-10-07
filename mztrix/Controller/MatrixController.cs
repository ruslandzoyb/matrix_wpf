using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mztrix.Controller
{
   public class MatrixController
    {
        Matrix_name.Matrix[] matrixs = new Matrix_name.Matrix[2];
         


        public MatrixController(double[,] array,
            ushort row1,
            ushort column1,
            double[,] array2,
            ushort row2,
            ushort column2 )
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array2 == null)
            {
                throw new ArgumentNullException(nameof(array2));
            }

            matrixs[0] = new Matrix_name.Matrix(array, row1, column1);
            matrixs[1] = new Matrix_name.Matrix(array2, row2, column2);
        } 
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;

namespace polyDataTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            polyDataTest1();
        }
        public static void polyDataTest1()
        {
            vtkPoints pPoints = vtkPoints.New();
            pPoints.InsertPoint(0, 0.0, 0.0, 0.0); // ID, x, y, z
            pPoints.InsertPoint(1, 0.0, 1.0, 0.0);
            pPoints.InsertPoint(2, 1.0, 0.0, 0.0);
            pPoints.InsertPoint(3, 1.0, 1.0, 0.0);

            vtkCellArray pPolys = vtkCellArray.New();
            pPolys.InsertNextCell(3); // number of points
            pPolys.InsertCellPoint(0);  // Point's ID
            pPolys.InsertCellPoint(1);
            pPolys.InsertCellPoint(2);
            pPolys.InsertNextCell(3); // number of points
            pPolys.InsertCellPoint(1);  // Point's ID
            pPolys.InsertCellPoint(3);
            pPolys.InsertCellPoint(2);

            vtkPolyData pPolyData = vtkPolyData.New();
            pPolyData.SetPoints(pPoints);
            pPolyData.SetPolys(pPolys);

            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInput(pPolyData);

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            vtkRenderer renderer = vtkRenderer.New();
            renderer.AddActor(actor);
            renderer.SetBackground(.1, .2, .3);
            renderer.ResetCamera();

            vtkRenderWindow renderWin = vtkRenderWindow.New();
            renderWin.AddRenderer(renderer);

            vtkRenderWindowInteractor interactor = vtkRenderWindowInteractor.New();
            interactor.SetRenderWindow(renderWin);

            renderWin.Render();
            interactor.Start();
        }

    }
}

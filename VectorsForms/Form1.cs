using System.Data.SqlClient;
using System.Data;
using System;

namespace VectorsForms
{
    public partial class Form1 : Form
    {
        VectorMapper vectorMapperList;
        TriangleMapper triangleMapperList;

        Mapper vectorMapper;
        Mapper triangleMapper;


        public Form1()
        {
            InitializeComponent();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            vectorMapper = new Mapper("vectors");
            triangleMapper = new Mapper("triangles");

            vectorMapperList = new VectorMapper();
            triangleMapperList = new TriangleMapper();
            CreateColumns();
            updateGridVectors();
            updateGridTriangles();
        }        
        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("x", "x");
            dataGridView1.Columns.Add("y", "y");

            triangleDataGridView.Columns.Add("id", "id");
            triangleDataGridView.Columns.Add("v1_id", "v1_id");
            triangleDataGridView.Columns.Add("x", "x");
            triangleDataGridView.Columns.Add("y", "y");
            triangleDataGridView.Columns.Add("v2_id", "v2_id");
            triangleDataGridView.Columns.Add("x", "x");
            triangleDataGridView.Columns.Add("y", "y");
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            double x=Convert.ToDouble(vectorAddX.Text);
            double y= Convert.ToDouble(vectorAddY.Text);
            Vector v = new Vector(new List<string> { "0",Convert.ToString(x), Convert.ToString(y)});
            
            vectorMapper.Insert(v);
            updateGridVectors();
        }        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        public void updateGridVectors()
        {
            dataGridView1.Rows.Clear();
            List<Vector> vectors = vectorMapperList.SelectAll();
            for(int i = 0; i < vectors.Count(); i++)
            {
                dataGridView1.Rows.Add(vectors[i]._id, vectors[i]._x, vectors[i]._y);
            }            
        }
        public void updateGridTriangles()
        {
            triangleDataGridView.Rows.Clear();
            List<Triangle> triangles = triangleMapperList.SelectAll();
            for (int i = 0; i < triangles.Count(); i++)
            {
                triangleDataGridView.Rows.Add(triangles[i]._id, triangles[i].v1._id, 
                    triangles[i].v1._x, triangles[i].v1._y, 
                    triangles[i].v2._id, triangles[i].v2._x, triangles[i].v2._y);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textDelById_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(vectorDelById.Text);

            if (!vectorMapper.Delete(id))
            {
                MessageBox.Show("Вектор не найден, проверьте id","DELETE");
            }
            updateGridVectors();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(vectorUpdateX.Text);
            double y = Convert.ToDouble(vectorUpdateY.Text);
            int id = Convert.ToInt32(vectorUpdateById.Text);

            Vector v = new Vector(new List<string> { Convert.ToString(id), Convert.ToString(x), Convert.ToString(y) }); ;
            if (!vectorMapper.Update(v))
            {
                MessageBox.Show("Вектор не найден, проверьте id", "UPDATE");
            }
            updateGridVectors();
        }

        private void triangleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int v1_id = Convert.ToInt32(triangleAddX.Text);
            int v2_id = Convert.ToInt32(triangleAddY.Text);
            Triangle t = new Triangle(new List<string> { "0",Convert.ToString(v1_id), Convert.ToString(v2_id)});
            try
            {
                triangleMapper.Insert(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Таких векторов нет в базе, проверьте id", "INSERT");
            }
            
            updateGridTriangles();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(triangleDelById.Text);
            if (!triangleMapper.Delete(id))
            {
                MessageBox.Show("Треугольник не найден, проверьте id", "DELETE");
            }
            updateGridTriangles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int v1_id = Convert.ToInt32(triangleUpdateX.Text);
            int v2_id = Convert.ToInt32(triangleUpdateY.Text);
            int id = Convert.ToInt32(triangleUpdateById.Text);
            Triangle t= new Triangle(new List<string> { Convert.ToString(id), Convert.ToString(v1_id), Convert.ToString(v2_id) });
            if (!triangleMapper.Update(t))
            {
                MessageBox.Show("Треугольник не найден, проверьте id", "UPDATE");
            }
            updateGridTriangles();
        }

        private void triangleAddX_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
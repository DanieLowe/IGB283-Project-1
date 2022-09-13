using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGB283Transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private const int matrixOrder = 3;
	public float angle = 10f;
	// Static Variables
	// The identiy matrix
	public static IGB283Transform identity
	{
		get
		{
			//create new 3x3 matrix
			IGB283Transform i = new IGB283Transform();

			//set the rows of the matrix

			i.SetRow(0, new Vector3(1.0f, 0.0f, 0.0f));
			i.SetRow(1, new Vector3(0.0f, 1.0f, 0.0f));
			i.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

			return i;
		}
	}

	// The zero matrix
	private static Vector3 zeroVector = new Vector3(0.0f, 0.0f, 0.0f);
	public static IGB283Transform zero
	{
		get
		{
			return new IGB283Transform(
				zeroVector,
				zeroVector,
				zeroVector
			);
		}
	}

	// Variables
	// The determinant of the matrix
	public float determinant
	{
		get
		{
			return
				m[0][0] * (m[1][1] * m[2][2] - m[1][2] * m[2][1])
				- m[0][1] * (m[1][0] * m[2][2] - m[1][2] * m[2][0])
				+ m[0][2] * (m[1][0] * m[2][1] - m[1][1] * m[2][0]);
		}
		set
		{
			throw new System.NotImplementedException();
		}
	}


	// The inverse of the matrix
	//TODO
	public IGB283Transform inverse
	{
		get
		{
			return (1 / determinant) * (new IGB283Transform(
				new Vector3(
					(m[1][1] * m[2][2] - m[1][2] * m[2][1]),
					-(m[1][0] * m[2][2] - m[1][2] * m[2][0]),
					(m[1][0] * m[2][1] - m[1][1] * m[2][0])
				),
				new Vector3(
					-(m[0][1] * m[2][2] - m[0][2] * m[2][1]),
					(m[0][0] * m[2][2] - m[0][2] * m[2][0]),
					-(m[0][0] * m[2][1] - m[0][1] * m[2][0])
				),
				new Vector3(
					(m[0][1] * m[1][2] - m[0][2] * m[1][1]),
					-(m[0][0] * m[1][2] - m[0][2] * m[1][0]),
					(m[0][0] * m[1][1] - m[0][1] * m[1][0])
				)
			).transpose);
		}
	}

	// Is the matrix an identity matrix
	//TODO
	public bool isIdentity
	{
		get
		{
			return this.Equals(identity);
		}
		set
		{
			throw new System.NotImplementedException();
		}
	}

	// The element at x, y
	public float this[int row, int column]
	{
		get
		{
			return m[row][column];
		}
		set
		{
			Vector3 v = m[row];
			v[column] = value;
			m[row] = v;
		}
	}

	// The transpose of the matrix
	public IGB283Transform transpose
	{
		get
		{
			IGB283Transform newMatrix = new IGB283Transform();

			for (int i = 0; i < matrixOrder; i++)
			{
				newMatrix.SetColumn(i, this.GetRow(i));
			}
			return newMatrix;
		}
	}

	// Constructor
	// Arraylist to contain the vector data
	private List<Vector3> m = new List<Vector3>();

	// Create a matrix 3x3 with specified values
	private IGB283Transform(Vector3 r1, Vector3 r2, Vector3 r3)
	{
		m.Add(r1);
		m.Add(r2);
		m.Add(r3);
	}

	// Create a matrix 3x3 initialised with zeros
	public IGB283Transform()
	{
		m.Add(zeroVector);
		m.Add(zeroVector);
		m.Add(zeroVector);
	}

	// Public Functions
	// get a column of the matrix
	public Vector3 GetColumn(int column)
	{
		return new Vector3(m[0][column], m[1][column], m[2][column]);
	}

	// get a row of the matrix
	public Vector3 GetRow(int row)
	{
		return m[row];
	}

	// Transform a point by this matrix
	public Vector3 MultiplyPoint(Vector3 p)
	{
		p.z = 1.0f;
		Vector3 v = new Vector3(
			m[0][0] * p[0] + m[0][1] * p[1] + m[0][2] * p[2],
			m[1][0] * p[0] + m[1][1] * p[1] + m[1][2] * p[2],
			m[2][0] * p[0] + m[2][1] * p[1] + m[2][2] * p[2]
		);
		return v;
	}
	// Transform a direction by this matrix
	public Vector3 MultiplyPoint3x4(Vector3 p)
	{
		throw new System.NotImplementedException();
	}

	// Set a column of the matrix
	public Vector3 MultiplyVector(Vector3 v)
	{
		throw new System.NotImplementedException();
	}

	// Set a column of the matrix
	public void SetColumn(int index, Vector3 column)
	{
		// Get the three row vectors of the matrix
		Vector3 r1 = m[0];
		Vector3 r2 = m[1];
		Vector3 r3 = m[2];

		// Set the index'th value to be the value from the column vector
		r1[index] = column[0];
		r2[index] = column[1];
		r3[index] = column[2];

		// Reassign the rows to he matrix
		m[0] = r1;
		m[1] = r2;
		m[2] = r3;
	}

	// Set a row of the matrix
	public void SetRow(int index, Vector3 row)
	{
		m[index] = row;
	}

	// Sets this matrix to a translation, rotation and scaling matrix
	public void SetTRS(Vector3 pos, Quaternion q, Vector3 s)
	{
		throw new System.NotImplementedException("If you want to use this method you will need to implement it yourself");
	}
	// Return a string of the matrix
	public override string ToString()
	{
		string s = "";
		s = string.Format(
			 "{0,-12:0.00000}{1,-12:0.00000}{2,-12:0.00000}\r\n" +
			 "{3,-12:0.00000}{4,-12:0.00000}{5,-12:0.00000}\r\n" +
			 "{6,-12:0.00000}{7,-12:0.00000}{8,-12:0.00000}\r\n",
			m[0].x, m[0].y, m[0].z,
			m[1].x, m[1].y, m[1].z,
			m[2].x, m[2].y, m[2].z);

		return s;
	}

	// Operators
	// Multiply two matrices together
	public static IGB283Transform operator *(IGB283Transform b, IGB283Transform c)
	{
		//new 3x3matrix to store values
		IGB283Transform newMatrix = new IGB283Transform();

		// for each row in b multiply by c and find new row
		for (int i = 0; i < matrixOrder; i++)
		{
			Vector3 r = new Vector3(
				b[i, 0] * c[0, 0] + b[i, 1] * c[1, 0] + b[i, 2] * c[2, 0],
				b[i, 0] * c[0, 1] + b[i, 1] * c[1, 1] + b[i, 2] * c[2, 1],
				b[i, 0] * c[0, 2] + b[i, 1] * c[1, 2] + b[i, 2] * c[2, 2]);

			newMatrix.SetRow(i, r);
		}

		return newMatrix;
	}

	// Multiply a matrix by a scalar 
	public static IGB283Transform operator *(float b, IGB283Transform c)
	{
		//new matrix 3x3 to store the values
		IGB283Transform newMatrix = new IGB283Transform();

		//multiply each element in c by b
		for (int i = 0; i < matrixOrder; i++)
		{
			for (int j = 0; j < matrixOrder; j++)
			{
				newMatrix[i, j] = c[i, j] * b;
			}
		}

		return newMatrix;
	}

	public static IGB283Transform operator *(IGB283Transform c, float b)
	{
		return b * c;
	}

	// Test the equality of this matrix and another
	public bool Equals(IGB283Transform m2)
	{

		//for each row
		for (int i = 0; i < matrixOrder; i++)
		{
			//for each column
			for (int j = 0; j < matrixOrder; j++)
			{
				if (this[i, j] != m2[i, j])
				{
					return false;
				}
			}
		}
		return true;
	}

	public IGB283Transform Rotate(float angle)
	{
		//create new matrix
		IGB283Transform matrix = new IGB283Transform();

		//set the rows
		matrix.SetRow(0, new Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0.0f));
		matrix.SetRow(1, new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f));
		matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}

	
	public IGB283Transform Translate(Vector3 translate)
	{
		//create new matrix
		IGB283Transform matrix = new IGB283Transform();

		//set the rows
		matrix.SetRow(0, new Vector3(1.0f, 0.0f, translate.x));
		matrix.SetRow(1, new Vector3(0.0f, 1.0f, translate.y));
		matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}
}

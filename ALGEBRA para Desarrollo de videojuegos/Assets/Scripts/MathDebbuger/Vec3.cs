﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { return x * x + y * y + z * z; } }
        public Vec3 normalized { get { return Normalize(this); } }
        public float magnitude { get { return Magnitude(this); } }
        #endregion

        #region constants
        public const float epsilon = 1e-05f;
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            float diff_x = left.x - right.x;
            float diff_y = left.y - right.y;
            float diff_z = left.z - right.z;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrmag < epsilon * epsilon;
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - rightV3.x, leftV3.y - rightV3.y, leftV3.z - rightV3.z);
            // throw new NotImplementedException();
        }

        public static Vec3 operator -(Vec3 v3)
        {
            return new Vec3(-1 * v3.x, -1 * v3.y, -1 * v3.z);

            //throw new NotImplementedException();
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }

        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return new Vec3(scalar * v3.x, scalar * v3.y, scalar * v3.z);
        }

        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x / scalar, v3.y / scalar, v3.z / scalar);
            // throw new NotImplementedException();
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
            //throw new NotImplementedException();
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            float num = Mathf.Sqrt(from.sqrMagnitude * to.sqrMagnitude);

            if (num < epsilon)
            {
                return 0f;
            }

            float num2 = Dot(from,to) / num;

            return Mathf.Acos(num2);

            //throw new NotImplementedException();
        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {

            float num = vector.sqrMagnitude;
            if (num > maxLength * maxLength)
            {
                float num2 = (float)Math.Sqrt(num);
                float num3 = vector.x / num2;
                float num4 = vector.y / num2;
                float num5 = vector.z / num2;
                return new Vec3(num3 * maxLength, num4 * maxLength, num5 * maxLength);
            }

            return vector;
            // throw new NotImplementedException();
        }
        public static float Magnitude(Vec3 vector)
        {
            return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
           // throw new NotImplementedException();
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            return new Vec3((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x));
            //throw new NotImplementedException();
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
            float num = a.x - b.x;
            float num2 = a.y - b.y;
            float num3 = a.z - b.z;

            return Mathf.Sqrt(num * num + num2 * num2 + num3 * num3);

            // throw new NotImplementedException();
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;

            //throw new NotImplementedException();
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {
            t = Mathf.Clamp01(t);
            return a + (b - a) * t;
            //throw new NotImplementedException();
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            return a + (b - a) * t;
            // throw new NotImplementedException();
        }
        public static Vec3 Max(Vec3 a, Vec3 b)
        {
            return new Vec3(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y), Mathf.Max(a.z, b.z));

            //throw new NotImplementedException();
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            return new Vec3(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Min(a.z, b.z));

            //throw new NotImplementedException();
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
            //throw new NotImplementedException();
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal) 
        {
            float num = Dot(onNormal, onNormal);
            if (num < Mathf.Epsilon)
            {
                return Zero;
            }

            float num2 = Dot(vector, onNormal);
            return new Vec3(onNormal.x * num2 / num, onNormal.y * num2 / num, onNormal.z * num2 / num);
            //throw new NotImplementedException();
        }
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal) 
        {
            float num = -2f * Dot(inNormal, inDirection);
            return new Vec3(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y, num * inNormal.z + inDirection.z);
            //throw new NotImplementedException();
        }
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
            // throw new NotImplementedException();
        }
        public void Scale(Vec3 scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
            //throw new NotImplementedException();
        }

        public static Vec3 Normalize(Vec3 vec3)
        {
            float num = Magnitude(vec3);
            if (num > epsilon)
            {
                return vec3 / num;
            }

            return Zero;
        }

        public void Normalize()
        {
            float num = Magnitude(this);
            if (num > epsilon)
            {
                this /= num;
            }
            else
            {
                this = Zero;
            }
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}
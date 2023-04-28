using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomMath
{
    public struct Plane
    {
        private Vec3 _normal;
        private float _distance;

        /// <summary>
        /// Normal del plano
        /// </summary>
        public Vec3 normal
        {
            get { return _normal; }
            set { _normal = value; }
        }

        /// <summary>
        /// La distancia medida desde el Plano hasta el origen, a lo largo de la normal del Plano.
        /// </summary>
        public float distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        /// <summary>
        /// Crea un plano.
        /// </summary>
        /// <param name="inNormal"></param>
        /// <param name="inPoint"></param>
        public Plane(Vec3 inNormal, Vec3 inPoint)
        {
            _normal = Vec3.Normalize(inNormal);
            _distance = -Vec3.Dot(inNormal, inPoint);
        }

        /// <summary>
        /// Crea un plano.
        /// </summary>
        /// <param name="inNormal"></param>
        /// <param name="distance"></param>
        public Plane(Vec3 inNormal, float distance)
        {
            _normal = Vec3.Normalize(inNormal);
            _distance = distance;
        }

        /// <summary>
        /// Crea un plano.
        /// </summary>
        /// <param name="vecA"></param>
        /// <param name="vecB"></param>
        /// <param name="vecC"></param>
        public Plane(Vec3 vecA, Vec3 vecB, Vec3 vecC)
        {
            _normal = Vec3.Normalize(Vec3.Cross(vecB - vecA, vecC - vecA));
            _distance = -Vec3.Dot(_normal, vecA);
        }

    }
}
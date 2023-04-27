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
        public Plane(Vec3 inNormal, Vec3 inPoint)
        {
            _normal = Vec3.Normalize(inNormal);
            _distance = -Vec3.Dot(inNormal, inPoint);
        }
    }
}
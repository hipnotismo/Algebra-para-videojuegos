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

        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint)
        {
            _normal = Vec3.Normalize(inNormal);
            _distance = -Vec3.Dot(inNormal, inPoint);
        }

        /// <summary>
        /// Establece un plano utilizando tres puntos que se encuentran dentro de �l.
        /// Los puntos giran en el sentido de las agujas del reloj cuando miras hacia abajo en la superficie superior del plano.
        /// </summary>
        /// <param name="vectA"> Primer punto en el sentido de las agujas del reloj.</param>
        /// <param name="vecB"> Segundo punto en el sentido de las agujas del reloj.</param>
        /// <param name="vecC"> Tercer punto en el sentido de las agujas del reloj.</param>
        public void Set3Points(Vec3 vectA, Vec3 vecB, Vec3 vecC)
        {
            _normal = Vec3.Normalize(Vec3.Cross(vecB - vectA, vecC - vectA));
            _distance = -Vec3.Dot(_normal, vectA);
        }

        /// <summary>
        /// Hace que el plano mire en la direcci�n opuesta.
        /// </summary>
        public void Flip()
        {
            this._normal = -this._normal;
            this._distance = -this._distance;
        }

        /// <summary>
        /// Devuelve una copia del plano que mira en la direcci�n opuesta.
        /// </summary>
        public Plane flipped => new Plane(-this._normal, -this._distance);


        /// <summary>
        /// Mueve el plano en el espacio, tomando como referencia un vector.
        /// </summary>
        /// <param name="translation">El desplazamiento en el espacio para mover el plano</param>
        public void Translate(Vec3 translation) => this._distance += Vec3.Dot(this._normal, translation);

        /// <summary>
        /// Devuelve una copia del plano con la posicion modificada.
        /// </summary>
        /// <param name="plane">Plano que se mueve en el espacio.</param>
        /// <param name="translation">El desplazamiento para mover el plano.</param>
        /// <returns>The translated plane.</returns>
        public static Plane Translate(Plane plane, Vec3 translation) =>
            new Plane(plane.normal, plane.distance += Vec3.Dot(plane.normal, translation));

        /// <summary>
        /// Devuelve el punto mas cercano de un plano en base a una posicion dada.
        /// </summary>
        /// <param name="point">Punto que se projecta en el plano</param>
        /// <returns>Un punto en el plano que est� m�s cerca de una posicion.</returns>
        public Vec3 ClosestPointOnPlane(Vec3 point)
        {
            float dot = Vec3.Dot(this._normal, point) + this._distance;
            return point - this._normal * dot;
        }

        /// <summary>
        /// Devuelve una distancia con signo del plano al punto.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float GetDistanceToPoint(Vec3 point) => Vec3.Dot(this._normal, point) + this._distance;

        /// <summary>
        /// Chequea si hay un punto del lado positivo del plano.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool GetSide(Vec3 point) => (double)Vec3.Dot(this._normal, point) + (double)this._distance > 0.0;

        /// <summary>
        /// Chequea si estan los 2 puntos del mismo lado del plano.
        /// </summary>
        /// <param name="inPt0"></param>
        /// <param name="inPt1"></param>
        /// <returns></returns>
        public bool SameSide(Vec3 inPt0, Vec3 inPt1)
        {
            float distanceToPoint1 = this.GetDistanceToPoint(inPt0);
            float distanceToPoint2 = this.GetDistanceToPoint(inPt1);

            return (double)distanceToPoint1 > 0.0 && (double)distanceToPoint2 > 0.0 ||
                   (double)distanceToPoint1 <= 0.0 && (double)distanceToPoint2 <= 0.0;
        }

        public override string ToString() => $"normal:{this._normal}, distance:{this._distance}";
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public static class Utility
    {
        public static Vector3 RemoveNumberFractions(Vector3 vector3, bool clearZ)
        {
            if (vector3.x < 0.01f && vector3.x > -0.01f)
            {
                vector3.x = 0f;
            }

            if (vector3.y < 0.01f && vector3.y > -0.01f)
            {
                vector3.y = 0f;
            }
        
            if (vector3.z < 0.01f && vector3.z > -0.01f)
            {
                vector3.z = 0f;
            }

            if (clearZ)
            {
                vector3 = RemoveZAxis(vector3);
            }

            return vector3;
        }

        public static Vector3 RemoveZAxis(Vector3 vector3)
        {
            vector3.z = 0f;
            return vector3;
        }
    }
}
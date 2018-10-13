public static class Utilities{

  // Returns a new array containing the values between START and END in ARR
  public static T[] slice<T>(this T[] arr, int start, int end){
	   int len = end - start;

     T[] new_arr = new T[len];
	   for (int i = 0; i < len; i++){
	      new_arr[i] = arr[i + start];
	    }

      return new_arr;
    }

  // TODO: Write a more general version with 'params'
  // Concatenates two arrays and returns a new array
  public static T[] concatenate<T>(T[] arr1, T[] arr2){
    T[] z = new T[arr1.Length + arr2.Length];
    arr1.CopyTo(z, 0);
    arr2.CopyTo(z, arr1.Length);
    return z;
  }

}

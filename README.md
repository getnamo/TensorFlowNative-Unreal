# tensorflow-native-ue4
Tensorflow Plugin for Unreal Engine using C API for inference focus.


## Notes

- Supported platforms: Win64
- Bound to Tensorflow 1.13 version

Loads and [can use c_api directly](https://github.com/getnamo/tensorflow-native-ue4/blob/master/Source/TensorflowLib/Private/TensorflowLib.cpp#L12) (use ```#include "TensorflowCApi.h"```), but not yet easy to use. Work in progress.

Should be fairly easy to extend platform support to Linux, MacOS, and maybe even Android once a good workflow is implemented.

## Todo
see https://github.com/getnamo/tensorflow-native-ue4/issues/1

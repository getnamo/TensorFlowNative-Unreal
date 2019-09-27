# tensorflow-native-ue4
Tensorflow Plugin for Unreal Engine using C API for inference focus.

## TensorFlow Plugin Variants

Want to use tensorflow python api as an embedded instance? 

See https://github.com/getnamo/tensorflow-ue4

Want native inference focused support? (WIP)

See https://github.com/getnamo/tensorflow-native-ue4

Want to run tensorflow on a remote python server? (WIP)

See https://github.com/getnamo/tensorflow-remote-ue4

Want tensorflow.js? (WIP)

See https://github.com/getnamo/tensorflowjs-ue4

## Notes

- Supported platforms: Win64
- Bound to Tensorflow 1.13 version

Loads and [can use c_api directly](https://github.com/getnamo/tensorflow-native-ue4/blob/master/Source/TensorflowLib/Private/TensorflowLib.cpp#L12) (use ```#include "TensorflowCApi.h"```), but not yet easy to use. Work in progress.

## Todo
see https://github.com/getnamo/tensorflow-native-ue4/issues/1

# TensorFlowNative-Unreal
Tensorflow Plugin for Unreal Engine using C API for inference focus.

## TensorFlow Plugin Variants

Want to use tensorflow python api as an embedded instance? 

- https://github.com/getnamo/TensorFlow-Unreal

Want native inference focused support? (WIP)

- https://github.com/getnamo/TensorFlowNative-Unreal

Want to run tensorflow on a remote python server? (WIP)

- https://github.com/getnamo/MachineLearningRemote-Unreal

Want tensorflow.js? (WIP)

- https://github.com/getnamo/TensorFlowJs-Unreal

## Notes

- Supported platforms: Win64
- Bound to Tensorflow 1.13 version

Loads and [can use c_api directly](https://github.com/getnamo/tensorflow-native-ue4/blob/master/Source/TensorflowLib/Private/TensorflowLib.cpp#L12) (use ```#include "TensorflowCApi.h"```), but not yet easy to use. Work in progress.

## Todo
see https://github.com/getnamo/tensorflow-native-ue4/issues/1

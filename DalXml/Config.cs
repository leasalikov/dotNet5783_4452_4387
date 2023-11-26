﻿
namespace Dal;

internal static class Config
{
    static string s_data_config_xml = "data-config";
    internal static int NextDependnceId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextCourseId"); }
    internal static int NextTaskId { get => XMLTools.GetAndIncreaseNextId(s_data_config_xml, "NextLinkId"); }
}

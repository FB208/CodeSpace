<template>
<div>
    <div class="crumbs">
            <el-breadcrumb separator="/">
                <el-breadcrumb-item><i class="el-icon-lx-calendar"></i> 表单</el-breadcrumb-item>
                <el-breadcrumb-item>基本表单</el-breadcrumb-item>
            </el-breadcrumb>
        </div>
</div>
    <el-form ref="form" :model="formdata" label-width="160px" size="mini">
        <div style="margin:20px;">
            <fieldset>
                <legend>需求基础信息</legend>
                <el-row>
                    <el-col :span="12">
                        <el-form-item label="需求名称">
                            <el-input v-model="formdata.name"></el-input>
                        </el-form-item>
                    </el-col>
                    <el-col :span="12">
                        <el-form-item label="提出部门">
                            <el-cascader :options="deps" v-model="formdata.dep"></el-cascader>
                        </el-form-item>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="12">
                        <el-form-item label="提出人">
                            <el-input placeholder="张三" v-model="formdata.tcr" :disabled="true">
                            </el-input>
                        </el-form-item>
                    </el-col>
                    <el-col :span="12">
                        <el-form-item label="提出人联系电话">
                            <el-input v-model="formdata.tel" placeholder="12345678"></el-input>
                        </el-form-item>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="7">
                        <el-form-item label="是否监管要求">
                            <el-radio v-model="formdata.sfjgyq" label='1'>是</el-radio>
                            <el-radio v-model="formdata.sfjgyq" label='0'>否</el-radio>
                        </el-form-item>
                    </el-col>
                    <el-col :span="5">
                        <el-form-item label="时间要求" label-width="100px" v-if="formdata.sfjgyq=='1'?true:false">
                            <el-input v-model="formdata.sjyq" placeholder="12345678"></el-input>
                        </el-form-item>
                        <el-form-item label=" " v-if="formdata.sfjgyq=='0'?true:false">
                        </el-form-item>
                    </el-col>
                    <el-col :span="12">
                        <el-form-item label="需求符合人">
                            <el-select v-model="value" placeholder="-请选择-">
                                <el-option v-for="item in xqfhrs" :key="item.value" :label="item.label" :value="item.value">
                                </el-option>
                            </el-select>
                        </el-form-item>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <el-form-item label="需求背景">
                            <el-input type="textarea" :autosize="{ minRows: 3, maxRows: 10}" placeholder="请输入内容" v-model="formdata.xqbj">
                            </el-input>
                        </el-form-item>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="24">
                        <el-form-item label="需求内容">
                            <el-input type="textarea" :autosize="{ minRows: 3, maxRows: 10}" placeholder="请输入内容" v-model="formdata.xqnr">
                            </el-input>
                        </el-form-item>
                    </el-col>
                </el-row>
                <el-row>
                    <el-col :span="12">
                        <el-form-item label="需求附件">
                            <!-- <el-upload class="upload-demo" action="https://jsonplaceholder.typicode.com/posts/" :on-preview="handlePreview" :on-remove="handleRemove" :before-remove="beforeRemove" multiple :limit="3" :on-exceed="handleExceed" :file-list="fileList">
                                <el-button size="small" type="primary">点击上传</el-button>
                                <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
                            </el-upload> -->
                        </el-form-item>
                    </el-col>
                </el-row>
            </fieldset>
            <fieldset>
                <legend>需求联系人</legend>
                <el-row>
                    <el-col :span="12">
                        <el-form-item label="提出部门其他联系人">
                            <el-select v-model="formdata.tcbmlxr" multiple placeholder="-请选择-">
    <el-option
      v-for="item in xqfhrs"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
                        </el-form-item>
                    </el-col>
                    <el-col :span="12">
                        <el-form-item label="配合部门联系人">
                            <el-button type="primary" round  @click="dialogFormVisible = true">主要按钮</el-button>
                        </el-form-item>
                    </el-col>
                </el-row>

            </fieldset>

            <el-form-item size="large">
                <el-button type="primary" @click="onSubmit">立即创建</el-button>
                <el-button>取消</el-button>
            </el-form-item>
        </div>

<el-dialog title="收货地址" :visible.sync="dialogFormVisible">
   <div style="text-align: center">
    <FBTest></FBTest>
  </div>
  <div slot="footer" class="dialog-footer">
    <el-button @click="dialogFormVisible = false">取 消</el-button>
    <el-button type="primary" @click="dialogFormVisible = false">确 定</el-button>
  </div>
</el-dialog>
    </el-form>
</template>
<script>
export default {
  data() {
    return {
      formdata: {
        name: "",
        tcr: "",
        tel: "",
        sfjgyq: "1",
        sjyq: "",
        xqbj: "",
        xqnr: "",
        region: "",
        date1: "",
        date2: "",
        delivery: false,
        type: [],
        resource: "",
        desc: ""
      },
      dialogFormVisible:false,
      deps: [
        {
          label: "部门1",
          value: "1",
          children: [{ label: "团队1", value: "1" }, { label: "团队2", value: "1" }]
        },
        {
          label: "部门2",
          value: "1",
          children: [{ label: "团队3", value: "1" }, { label: "团队4", value: "1" }]
        }
      ],
      xqfhrs: [
        { value: 1, label: "张三" },
        { value: 2, label: "李四" },
        { value: 3, label: "王五" },{ value: 4, label: "赵六" }
      ],
      
    };
  },
  methods: {
    onSubmit() {
      console.log("submit!");
    }
  }
};
</script>

<style>
fieldset {
  margin-bottom: 10px;
  padding: 10px;
  border-width: 1px;
  border-style: solid;
  border-color: #e6e6e6;
  border-radius: 4px;
}
</style>
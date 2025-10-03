* 邮箱配置

git config --global user.email "peixinhuang0428@gmail.com"

git config --global user.name "PeiXinHuang"



* 公钥配置

ssh-keygen -t rsa -C "peixinhuang0428@gmail.com"

生成位置 C:\\Users\\17169\\.ssh\\id\_rsa.pub

将公钥内容复制到github的SSH and GPG keys中



* 项目上传

git add .

git commit -m "first commit"

git remote add origin git@github.com:PeiXinHuang/G1.git

git push -u origin master


class ProfilesController < ApplicationController
  skip_before_filter :setname, :only => [:edit, :update]
  load_and_authorize_resource

  def show
    @profile = Profile.find( params[:id] )
    @tasks = @profile.user.resolved_tasks
  end

  def update
      @profile = Profile.find( params[:id] ) 
      @profile.update_attributes(params[:profile])
      if @profile.save
        flash[:notice] = "Successfully created user."
        redirect_to @profile
      end
  end


  def destroy
    @profile = Profile.find(params[:id])
    @profile.destroy

    redirect_to profiles_url
  end




  def index
    if params[:task_id]
      @task = Task.find(params[:task_id])
      @profiles = @task.passed_users.paginate(:page => params[:page], :per_page => 5)  
      render "passedusers"
    else
    @profiles = Profile.paginate(:page => params[:page], :per_page => 5)
    end
  end

end

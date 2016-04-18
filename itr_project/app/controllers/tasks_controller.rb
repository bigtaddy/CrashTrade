class TasksController < ApplicationController
  load_and_authorize_resource
  def index
    if params[:tag]
      @tasks = Task.tagged_with(params[:tag]).paginate(:page => params[:page], :per_page => 5)
    elsif params[:search]
      @tasks = Task.search {
      fulltext params[:search]do
        phrase_slop 1
        end 
      paginate(:page => params[:page], :per_page => 5)
      }.results
    elsif params[:profile_id]
      @profile = Profile.find(params[:profile_id])
      @tasks = @profile.user.resolved_tasks.paginate(:page => params[:page], :per_page => 5)
      render "resolvedtasks"
    else
      @tasks = Task.order('created_at DESC').paginate(:page => params[:page], :per_page => 5)
    end
  end

  def vote
    @task = Task.find(params[:id])
    current_user.vote_for(@task) if params[:title] == "Up"
    current_user.vote_against(@task) if params[:title] == "Down"
    redirect_to @task, notice: 'You successfully vote.'
  end


  def get_tags
    @tags = Task.tag_counts.order('count DESC').limit(3).where('tags.name LIKE ?', "%#{params[:q]}%")
    render :get_tags, :layout => false
  end


  def resolve 
    @resolv_task = Task.find(params[:id])    
    if @resolv_task.answer_list.include?(params[:answer_list]) 
      you_resolve( @resolv_task )
      redirect_to @resolv_task, notice: 'You successfully resolve this task.' 
    else
      redirect_to @resolv_task, notice: 'Incorrect, try again...' 
    end
  end



  def show
    @task = Task.find(params[:id])
  end

  def new
    content = Rails.cache.read("persisted_store_#{current_user.id}")
    @task = Task.new(:content => content)
  end

  def edit
    @task = Task.find(params[:id])
  end



  def create
    @task = current_user.created_tasks.new(params[:task])
      if @task.save
        redirect_to @task, notice: 'Task was successfully created.'
      else
        render action: "new" 
      end
  end

  def update
    @task = Task.find(params[:id])

      if @task.update_attributes(params[:task])
        redirect_to @task, notice: 'Task was successfully updated.' 
      else
        redirect_to @task, notice: 'Error'
      end
  end


  def destroy
    @task = Task.find(params[:id])
    @task.destroy

    redirect_to tasks_url
  end

  def persisted_store
    Rails.cache.write("persisted_store_#{current_user.id}", params[:data])
    render :nothing => true
  end


  private
  

  def you_resolve( task )
   current_user.resolved_tasks << task
  end
end
